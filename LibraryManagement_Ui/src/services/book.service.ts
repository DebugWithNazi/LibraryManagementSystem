import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddBookDto, AddBookListDto, AddedBookDto, PaginatedBooksDto, UpdateBookDto, UpdatedBookDto } from 'src/app/Models';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'https://localhost:7059/Books';

  constructor(private http: HttpClient) {}
 
  createBooks(request: AddBookListDto): Observable<AddedBookDto[]> {
    debugger;
    return this.http.post<AddedBookDto[]>(this.apiUrl, request );
  }
 
  getListBooks(page: number = 0): Observable<PaginatedBooksDto[]> {
    debugger;
    return this.http.get<PaginatedBooksDto[]>(`${this.apiUrl}?page=${page}`);
  }
 
  updateBook(isbn: string, dto: UpdateBookDto): Observable<UpdatedBookDto> {
    return this.http.put<UpdatedBookDto>(`${this.apiUrl}/${isbn}`, dto);
  }

  DeleteBook(isbn: string): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${isbn}`);
  }
}
