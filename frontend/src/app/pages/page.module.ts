import { NgModule } from '@angular/core';

import { AboutComponent } from './about/about.component';
import { NotFoundComponent } from './errors/not-found.component';
import { HomeComponent } from './home/home.component';

@NgModule({
    imports: [],
    declarations: [ HomeComponent, AboutComponent, NotFoundComponent],
    exports: []
})
export class PageModule {}