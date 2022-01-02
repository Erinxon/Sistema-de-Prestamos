import { Directive, ElementRef, Input, SimpleChanges } from '@angular/core';

@Directive({
  selector: '[appIniciales]'
})
export class InicialesDirective {
  @Input() appIniciales!: [string,string];

  constructor(private readonly elRef: ElementRef) {
  
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.elRef.nativeElement.setAttribute('data-initial', this.getLetrasIniciales);
  }

  private get getLetrasIniciales(): string {
    return this.appIniciales[0].charAt(0) + this.appIniciales[1].charAt(0);
  }
}
