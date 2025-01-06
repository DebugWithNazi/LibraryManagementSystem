import { Component, OnInit, ViewChild } from '@angular/core';
import { BookDto, BorrowedBookDto, PaginatedBooksDto } from '../Models';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { BookService } from 'src/services/book.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BorrowService } from 'src/services/borrow.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-my-books',
  templateUrl: './my-books.component.html',
  styleUrls: ['./my-books.component.scss']
})
export class MyBooksComponent implements OnInit {
  dataSource: BorrowedBookDto[] = [];
  displayedColumns: string[] = ['isbn', 'borrowedAt', 'returnedAt', 'actions'];
  title = 'My Books';

  constructor(private borrowService: BorrowService,
    private toastr: ToastrService,
    public authService: AuthService

  ) { }

  ngOnInit(): void {
    if (this.authService.isAdmin) {
      this.title = 'All Issued Books';
    }

    this.loadBorrowedBooks();
  }

  loadBorrowedBooks(): void {
    this.borrowService.getBorrowedBooks().subscribe((response: any) => {
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
