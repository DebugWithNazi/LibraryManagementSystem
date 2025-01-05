import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddBorrowBookDto, BorrowedBookDto } from 'src/app/Models';

@Injectable({
  providedIn: 'root'
})
export class BorrowService {
  private apiUrl = 'https://localhost:7059/Borrow';

  constructor(private http: HttpClient) { }

  /**
   * Borrow a book
   * @param request - AddBorrowBookDto object containing book and user details
   */
  borrowBook(request: AddBorrowBookDto): Observable<BorrowedBookDto> {
    return this.http.post<BorrowedBookDto>(`${this.apiUrl}/borrow`, request);
  }

  /**
   * Return a borrowed book
   * @param isbn - ISBN of the book to be returned
   */
  returnBook(isbn: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/return/${isbn}`);
  }

  /**
   * Get the list of borrowed books
   */
  getBorrowedBooks(): Observable<{ Books: BorrowedBookDto[] }> {
    return this.http.get<{ Books: BorrowedBookDto[] }>(`${this.apiUrl}/borrowed`);
  }

  /**
 * Get the list of All borrowed books
 */
  getReturnedBooks(): Observable<{ Books: BorrowedBookDto[] }> {
    return this.http.get<{ Books: BorrowedBookDto[] }>(`${this.apiUrl}/returned`);
  }
}
