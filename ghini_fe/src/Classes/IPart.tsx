import { Product } from "./Product";

export interface IPart{
    addCompatibility(p: Product) : void;
    removeCompatibility(p: Product) :boolean;
    getCompatibilities():Product[];
}