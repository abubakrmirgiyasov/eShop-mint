export interface IProduct {
    id: string;
    name: string;
    sku: string;
    shortDescription?: string;
    description?: string;
    adminComment?: string;
    photos?: string[];
    showOnHomePage?: boolean;
    countryOfOrigin?: string;
    gtin?: string;
    price: number;
    oldPrice?: number;
    isPublished?: boolean;
    isFreeTax?: boolean;
    taxPrice?: number;
    deliveryMinDay?: number;
    deliveryMaxDay?: number;
    rating?: number;
    manufacture?: string;
    store?: string;
    discount?: string;
    quantity: number;
}