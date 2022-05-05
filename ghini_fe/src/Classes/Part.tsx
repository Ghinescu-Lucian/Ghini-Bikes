import { IPart } from "./IPart";
import { Product } from "./Product";

export class Part extends Product implements IPart {

    protected compatibleProducts: Product[];

    public constructor(theName: string, thePrice: number, theDescription: string,
        theQuantity: number = 0, theManufacturer: string, theYear: number, theWeight: number) {

        super(theName, thePrice, theDescription, theQuantity, theManufacturer, theYear);
        this.compatibleProducts = [];
    }
    addCompatibility(p: Product) {
        this.compatibleProducts.push(p);
    }
    removeCompatibility(p: Product) {
        let ok: boolean;
        ok=false;
        for (let prod of this.compatibleProducts) {
            if (prod.name === p.name && prod.manufacturer == p.manufacturer && prod.year == p.year) {
                let index = this.compatibleProducts.indexOf(prod);
                 this.compatibleProducts.splice(index,1);
                 ok=true;
            }
        }
        return ok;
    }
    getCompatibilities():Product[]{
        return this.compatibleProducts;
    }

}