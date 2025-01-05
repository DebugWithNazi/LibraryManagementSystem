import { Component, OnInit } from '@angular/core';
import { BorrowedBookDto } from '../Models';
import { BorrowService } from 'src/services/borrow.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-borrowing-list',
  templateUrl: './borrowing-list.component.html',
  styleUrls: ['./borrowing-list.component.scss']
})
export class BorrowingListComponent implements OnInit {
  dataSource: BorrowedBookDto[] = [];
  displayedColumns: string[] = ['isbn', 'borrowedAt', 'returnedAt', 'actions'];

  constructor(private borrowService: BorrowService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
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
