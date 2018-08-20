import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { AddWordPage } from './add-word';

@NgModule({
  declarations: [
    AddWordPage,
  ],
  imports: [
    IonicPageModule.forChild(AddWordPage),
  ],
})
export class AddWordPageModule {}
