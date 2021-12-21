import { ApiResponse } from "../api-response.model";
import { Pagination } from "./pagination.model";

export interface PagedResponse<T> extends ApiResponse<T> {
    pagination: Pagination;
}