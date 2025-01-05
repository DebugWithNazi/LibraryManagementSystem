import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-book-dialog',
  templateUrl: './edit-book-dialog.component.html',
  styleUrls: ['./edit-book-dialog.component.scss']
})
export class EditBookDialogComponent {
  editBookForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<EditBookDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder
  ) {
    this.editBookForm = this.createEditBookForm(data.book);
  }

  private createEditBookForm(bookData: any): FormGroup {
    return this.fb.group({
      isbn: [bookData.isbn || '', Validators.required],
      title: [bookData.title || '', Validators.required],
      author: [bookData.author || '', Validators.required],
      edition: [bookData.edition || ''],
      publisher: [bookData.publisher || ''],
      genre: [bookData.genre || ''],
      pageCount: [bookData.pageCount || '', Validators.pattern('^[0-9]*$')],
      language: [bookData.language || ''],
      publicationYear: [bookData.publicationYear || '', Validators.pattern('^[0-9]*$')],
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSave(): void {
    if (this.editBookForm.valid) {
      this.dialogRef.close(this.editBookForm.value);
    }
  }
}
