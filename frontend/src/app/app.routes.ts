import { NgModule, inject } from '@angular/core';
import { ActivatedRouteSnapshot, RouterModule, RouterStateSnapshot, Routes } from '@angular/router';
import { AuthorService } from './services/author.service';
import { BookService } from './services/book.service';
import { SubjectService } from './services/subject.service';
import { SaleTypeService } from './services/saletype.service';

export const routes: Routes = [
    { 
        path: 'autores', 
        loadComponent: () => import('./components/author/list-authors/list-authors.component').then((m) => m.ListAuthorsComponent),
        resolve: {
            authors: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
                const authorService = inject(AuthorService);
                return authorService.getAuthors();
            }
        },
    },
    { 
        path: 'autores/criar', 
        loadComponent: () => import('./components/author/create-author/create-author.component').then((m) => m.CreateAuthorComponent) 
    },
    { 
        path: 'autores/atualizar/:id', 
        loadComponent: () => import('./components/author/update-author/update-author.component').then((m) => m.UpdateAuthorComponent),
        resolve: {
            author: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
                const authorService = inject(AuthorService);
                return authorService.getAuthor(Number(route.paramMap.get('id')));
            }
        }
    },

    { 
        path: 'livros', 
        loadComponent: () => import('./components/book/list-books/list-books.component').then((m) => m.ListBooksComponent),
        resolve: {
            books: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
                const bookService = inject(BookService);
                return bookService.getBooks();
            }
        }
    },
    { 
        path: 'livros/criar', 
        loadComponent: () => import('./components/book/create-book/create-book.component').then((m) => m.CreateBookComponent) 
    },
    { 
        path: 'livros/atualizar/:id', 
        resolve: {
            book: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
                const bookService = inject(BookService);
                return bookService.getBook(Number(route.paramMap.get('id')));
            }
        },
        loadComponent: () => import('./components/book/update-book/update-book.component').then((m) => m.UpdateBookComponent) 
    },

    { 
        path: 'assuntos', 
        loadComponent: () => import('./components/subject/list-subjects/list-subjects.component').then((m) => m.ListSubjectsComponent),
        resolve: {
            subjects: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
                const subjectService = inject(SubjectService);
                return subjectService.getSubjects();
            }
        }
    },
    { 
        path: 'assuntos/criar', 
        loadComponent: () => import('./components/subject/create-subject/create-subject.component').then((m) => m.CreateSubjectComponent)
    },
    { 
        path: 'assuntos/atualizar/:id', 
        loadComponent: () => import('./components/subject/update-subject/update-subject.component').then((m) => m.UpdateSubjectComponent),
        resolve: {
            subject: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
                const subjectService = inject(SubjectService);
                return subjectService.getSubject(Number(route.paramMap.get('id')));
            }
        },
    },

    { 
        path: 'tipo-venda', 
        loadComponent: () => import('./components/saletype/list-saletypes/list-saletypes.component').then((m) => m.ListSaleTypesComponent),
        resolve: {
            saletypes: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
                const saletypeService = inject(SaleTypeService);
                return saletypeService.getSaleTypes();
            }
        }
    },
    { 
        path: 'tipo-venda/criar', 
        loadComponent: () => import('./components/saletype/create-saletype/create-saletype.component').then((m) => m.CreateSaleTypeComponent)
    },
    { 
        path: 'tipo-venda/atualizar/:id', 
        loadComponent: () => import('./components/saletype/update-saletype/update-saletype.component').then((m) => m.UpdateSaleTypeComponent),
        resolve: {
            saletype: (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
                const saletypeService = inject(SaleTypeService);
                return saletypeService.getSaleType(Number(route.paramMap.get('id')));
            }
        },
    },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }