import { Author } from "../author.model"

export type AuthorPayload = Omit<Author, 'id'>;