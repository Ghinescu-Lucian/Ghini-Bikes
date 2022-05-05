export class Product {
    name: string;
    manufacturer: string;
    year: number;
    price: number;
    description: string;
    private quantity: number;
   
    public constructor(theName: string, thePrice: number, theDescription: string, theQuantity: number = 0, theManufacturer:string, theYear:number) {
        this.name = theName;
        this.price = thePrice;
        this.description = theDescription;
        this.quantity = theQuantity;
        this.manufacturer = theManufacturer;
        this.year= theYear;
      
    }
    addQuantity(q: number) {
       this.quantity += q ;
    }
    removeQuantity(q: number){
        this.quantity -= q;
    }

}