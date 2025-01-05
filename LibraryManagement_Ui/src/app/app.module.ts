import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ListBooksComponent } from './list-books/list-books.component';
import { BorrowingListComponent } from './borrowing-list/borrowing-list.component';
import { MyBooksComponent } from './my-books/my-books.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { IssuedBooksComponent } from './issued-books/issued-books.component';
import { ReturnedBooksComponent } from './returned-books/returned-books.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { AddBookComponent } from './add-book/add-book.component';
import { AuthInterceptor } from 'src/services/auth.interceptor';
import { EditBookComponent } from './edit-book/edit-book.component';
import { EditBookDialogComponent } from './edit-book-dialog/edit-book-dialog.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    ListBooksComponent,
    AddBookComponent,
    BorrowingListComponent,
    MyBooksComponent,
    RegistrationComponent,
    LoginComponent,
    IssuedBooksComponent,
    ReturnedBooksComponent,
    EditBookComponent,
    EditBookDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    RouterModule,
    AppRoutingModule,
    FormsModule,
    MatFormFieldModule,
    MatDialogModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot()
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true, // Allows multiple interceptors
  },],
  bootstrap: [AppComponent]
})
export class AppModule { }
