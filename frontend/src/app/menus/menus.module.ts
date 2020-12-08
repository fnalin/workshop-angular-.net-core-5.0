import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuRodapeComponent } from './menu-rodape/menu-rodape.component';
import { MenuTopComponent } from './menu-top/menu-top.component';

@NgModule({
    imports: [ RouterModule ],
    declarations: [MenuTopComponent, MenuRodapeComponent],
    exports: [MenuTopComponent, MenuRodapeComponent ]
})
export class MenuModule { }