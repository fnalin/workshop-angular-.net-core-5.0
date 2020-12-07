import { NgModule } from '@angular/core';
import { MenuRodapeComponent } from './menu-rodape/menu-rodape.component';
import { MenuTopComponent } from './menu-top/menu-top.component';

@NgModule({
    imports: [],
    declarations: [MenuTopComponent, MenuRodapeComponent],
    exports: [MenuTopComponent, MenuRodapeComponent]
})
export class MenuModule { }