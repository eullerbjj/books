import { Subject } from "../subject.model"

export type SubjectPayload = Omit<Subject, 'id'>;