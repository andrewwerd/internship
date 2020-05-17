import { Pipe, PipeTransform } from '@angular/core';
@Pipe({name: 'mdl'})
export class MdlCurrencyPipe implements PipeTransform {
  transform(value: number): string {
    let s: string;
    if (value % 10 === 1 && value % 100 !== 11){
      s = ' лея';
    }
    else{
      s = ' леев';
    }
    return value + s;
  }
}
