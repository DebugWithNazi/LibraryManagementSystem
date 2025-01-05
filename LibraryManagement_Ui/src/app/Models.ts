export interface RegisterDto {
  username: string;
  email: string;
  password: string;
}

export interface LoginDto {
  username: string;
  password: string;
}

export interface LoggedinDto {
  email: string;
  username: string;
}

export interface BorrowedBook {
  isbn: string;
  title: string;
  author: string;
  borrowedAt: Date;
}
export interface AddBookDto {
  isbn: string;
  title: string;
  author: string;

}

export interface AddBookListDto {
  books: AddBookDto[];
}
export interface UpdatedBookDto {
  isbn: string;
  updatedAt: Date;
}
export interface UpdateBookDto {
  title: string;
  author: string;
  edition: string;
  publisher: string;
  genre: string;
  pageCount: number;
  language: string;
  publicationYear: number;
}
export interface AddedBookDto {
  isbn: string;
  addedAt: Date;
}
export interface PaginatedBooksDto {
  totalPages: number;
  page: number;
  books: BookDto[];
}

export interface BookDto {
  title: string;
  author: string;
  edition: string;
  publisher: string;
  isbn: string;
  genre: string;
  pageCount: string;
  language: string;
  publicationYear: number;
  addedAt: Date;
  updatedAt: Date;
}


export interface AddBorrowBookDto {
  isbn: string;
}

export interface BorrowedBookDto {
  isbn: string;
  borrowedAt: Date;
  returnedAt?: Date | null;
}
