import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListBooksComponent } from './list-books/list-books.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { AddBookComponent } from './add-book/add-book.component';
import { MyBooksComponent } from './my-books/my-books.component';
import { BorrowingListComponent } from './borrowing-list/borrowing-list.component';


const routes: Routes = [
  { path: 'books-list', component: ListBooksComponent },
  { path: 'all-returned-books', component: BorrowingListComponent },
  { path: 'all-borrowed-books', component: BorrowingListComponent },
  { path: 'my-books', component: MyBooksComponent },
  { path: 'all-issued-books', component: MyBooksComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: 'add', component: AddBookComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }