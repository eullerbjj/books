import { SaleType } from "../saletype.model"

export type SaleTypePayload = Omit<SaleType, 'id'>;