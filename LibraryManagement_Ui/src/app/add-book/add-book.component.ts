import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { AddBookListDto } from '../Models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent {
  bookForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private bookService: BookService,
    private toastr: ToastrService,
    private router: Router,
  ) {
    this.bookForm = this.fb.group({
      books: this.fb.array([this.createBookFormGroup()])
    });
  }

  get books(): FormArray {
    return this.bookForm.get('books') as FormArray;
  }
  createBookFormGroup(): FormGroup {
    return this.fb.group({
      title: ['', Validators.required],
      author: ['', Validators.required],
      edition: [''],
      publisher: [''],
      isbn: ['', Validators.required],
      genre: [''],
      pageCount: [null, [Validators.required, Validators.min(1)]],
      language: [''],
      publicationYear: [null, [Validators.required, Validators.min(0)]],
    });
  }

  addBook(): void {
    this.books.push(this.createBookFormGroup());
  }

  removeBook(index: number): void {
    this.books.removeAt(index);
  }
  onSubmit(): void {
    debugger;
    if (this.bookForm.valid) {
      const request: AddBookListDto = {
        books: this.bookForm.value.books // Ensure this matches the expected format
      };

      this.bookService.createBooks(request).subscribe(
        (response) => {
          this.toastr.success('Books added successfully!');
          console.log('Added books:', response);
          this.bookForm.reset();
          this.books.clear();
          this.router.navigate(['/list-books']);
        },
        (error) => {
          console.error('Error adding books:', error);
          this.toastr.error('Failed to add books');
        }
      );
    } else {
      this.toastr.error('Please fill all required fields.');
    }
  }


  // onSubmit(): void {
  //   if (this.bookForm.valid) {
  //     this.bookService.createBooks(this.bookForm.value).subscribe(
  //       (response:any) => {
  //         debugger;
  //         this.toastr.success('Books added successfully');
  //         this.bookForm.reset();
  //         this.books.clear();
  //         this.addBook(); 
  //       },
  //       (error:any) => {
  //         debugger;
  //         this.toastr.error('Failed to add books');
  //       }
  //     );
  //   }
  // }
}
