import { Book } from "../book.model"

export type BookPayload = Omit<Book, 'id' | 'authors' | 'subjects'>;