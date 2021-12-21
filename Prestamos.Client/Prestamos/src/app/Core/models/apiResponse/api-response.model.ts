export interface ApiResponse<T> {
    data: T;
    statusCode: number;
    succeeded: boolean;
    message: string;
}