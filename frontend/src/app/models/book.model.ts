import { Author } from "./author.model";
import { Price } from "./price.model";
import { Subject } from "./subject.model";

export interface Book {
    id: number;
    title: string;
    publisher: string;
    edition: number;
    publicationYear: number;
    saleTypePrices: Price[];
    authorIds: number[];
    subjectIds: number[];
    authors: Author[];
    subjects: Subject[];
    prices: Price[];
}