export class Greeter {
    greeting: string;
    constructor(message: string) {
        this.greeting = message;
    }
    greet(gr:string) {
        return "Hello, " + gr+" !";
    }
}
