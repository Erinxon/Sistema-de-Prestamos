import { DOCUMENT } from '@angular/common';
import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { UserAuth } from 'src/app/Core/models/userAuth.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Input() user!: UserAuth;
  @Output() LogoutUser: EventEmitter<void> = new EventEmitter<void>();
  private sidebarMini: boolean = false;
  
  constructor(@Inject (DOCUMENT) private document: Document) { }

  ngOnInit(): void {
  }

  Logout(){
    this.LogoutUser.emit();
  }

  ocultarOMostrarMenu(){
    this.sidebarMini = !this.sidebarMini;
    if(this.contains('sidebar-gone')){
      this.deleteClass('sidebar-gone');
      this.addClass('sidebar-show');
    }else{
      if(this.sidebarMini){
        this.addClass('sidebar-mini');
      }else{
        this.deleteClass('sidebar-mini');
      }
    }
  }

  
  private contains(classCSS: string){
    return this.document.body.classList.contains(classCSS);
  }

  private addClass(classCSS: string){
    this.document.body.classList.add(classCSS);
  }

  private deleteClass(classCSS: string){
    this.document.body.classList.remove(classCSS);
  }

}
