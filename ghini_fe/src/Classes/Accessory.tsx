import { Product } from "./Product";

 export class  Bike extends Product{


    public constructor(theName: string, thePrice: number, theDescription: string,
         theQuantity: number = 0, theManufacturer:string, theYear:number) {
             
        super(theName, thePrice, theDescription,theQuantity,theManufacturer,theYear);
    }
 }