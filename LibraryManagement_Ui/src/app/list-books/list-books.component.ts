import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BookService } from 'src/services/book.service';
import { AddBorrowBookDto, BookDto, PaginatedBooksDto, UpdateBookDto, UpdatedBookDto } from '../Models';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { EditBookDialogComponent } from '../edit-book-dialog/edit-book-dialog.component';
import { BorrowService } from 'src/services/borrow.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-list-books',
  templateUrl: './list-books.component.html',
  styleUrls: ['./list-books.component.scss']
})
export class ListBooksComponent implements OnInit {
  displayedColumns: string[] = ['isbn', 'title', 'author', 'publisher', 'publicationYear', 'actions'];
  dataSource = new MatTableDataSource<PaginatedBooksDto[]>();
  totalPages: number = 0;
  page: number = 0;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private bookService: BookService,
    private router: Router, private dialog: MatDialog,
    private borrowService: BorrowService,
    private toastr: ToastrService,
    public authService: AuthService) { }

  ngOnInit(): void {
    this.loadBooks();
  }
  loadBooks(): void {
    this.bookService.getListBooks(this.page).subscribe((response: any) => {
      this.dataSource = response.books;
      this.totalPages = response.totalPages;
      this.page = response.page;
    });
  }

  onPageChange(event: any): void {
    this.page = event.pageIndex;
    this.loadBooks();
  }
  addBook(): void {
    this.router.navigate(['/add']);
  }

  openEditDialog(book: BookDto): void {
    const dialogRef = this.dialog.open(EditBookDialogComponent, {
      width: '600px',
      data: { book },
    });

    dialogRef.afterClosed().subscribe((updatedBook: UpdateBookDto | null) => {
      if (updatedBook) {
        this.bookService.updateBook(book.isbn, updatedBook).subscribe(
          (response: UpdatedBookDto) => {
            this.loadBooks();
          },
          (res) => {
            this.toastr.error('Failed to update book', res.error);
          }
        );
      }
    });
  }

  borrowBook(book: BookDto): void {
    const borrowRequest: AddBorrowBookDto = { isbn: book.isbn };
    this.borrowService.borrowBook(borrowRequest).subscribe(
      (response) => {
        this.toastr.success(`Successfully borrowed book: ${book.title}`);
      },
      (res) => {
        console.error('Error borrowing book:', res);
        this.toastr.error(res.error);
      }
    );
  }
}
