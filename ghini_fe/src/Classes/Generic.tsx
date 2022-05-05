 export class GenericType<T>{
     zeroValue: T | undefined;
     add: ((x: T, y: T) => T) | undefined;
     sub: ((x: T, y: T) => T) | undefined;
 }
