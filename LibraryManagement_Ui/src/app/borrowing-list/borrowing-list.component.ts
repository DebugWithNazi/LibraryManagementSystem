import { Component, OnInit } from '@angular/core';
import { BorrowedBookDto } from '../Models';
import { BorrowService } from 'src/services/borrow.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-borrowing-list',
  templateUrl: './borrowing-list.component.html',
  styleUrls: ['./borrowing-list.component.scss']
})
export class BorrowingListComponent implements OnInit {
  dataSource: BorrowedBookDto[] = [];
  displayedColumns: string[] = ['isbn', 'borrowedAt', 'returnedAt', 'actions'];
  title = 'All Borrowed Books';
  constructor(private borrowService: BorrowService,
    private toastr: ToastrService,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    if (this.authService.isAdmin) {
      this.title = 'All Returned Books';
    }

    this.loadBorrowedBooks();
  }

  loadBorrowedBooks(): void {
    this.borrowService.getReturnedBooks().subscribe((response: any) => {
      this.dataSource = response.books;
    });
  }

  returnBook(isbn: string): void {
    this.borrowService.returnBook(isbn).subscribe(() => {
      this.toastr.success('Book returned successfully!');
      this.loadBorrowedBooks();
    });
  }

}
