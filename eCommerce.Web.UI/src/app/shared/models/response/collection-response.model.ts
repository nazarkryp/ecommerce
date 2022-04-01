export interface CollectionResponse<T> {
    items: T[];
    total: number;
    size: number;
    page: number;
}
