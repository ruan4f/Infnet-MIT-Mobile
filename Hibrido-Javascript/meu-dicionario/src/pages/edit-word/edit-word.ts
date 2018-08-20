import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController, ToastController } from 'ionic-angular';
import { WordsProvider } from '../../providers/words/words';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

/**
 * Generated class for the EditWordPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-edit-word',
  templateUrl: 'edit-word.html',
})
export class EditWordPage {

  uid: string;
  word: any;
  editWordForm: FormGroup;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    private formBuilder: FormBuilder,
    private wordService: WordsProvider,
    private toast: ToastController,
    private loadingCtrl: LoadingController
  ) {
    this.uid = this.navParams.data.uid || '';
    this.word = this.navParams.data.word || {};
    this.createForm();
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad EditWordPage');
  }

  createForm() {
    this.editWordForm = this.formBuilder.group({
      key: [this.word.key],
      name: [this.word.name, Validators.required],
      description: [this.word.description, Validators.required],
    });
  }

  onSubmit() {
    let loading = this.loadingCtrl.create({
      content: 'Loading...'
    });
    loading.present();
    if (this.editWordForm.valid) {
      this.wordService.save(this.editWordForm.value, this.uid)
        .then(() => {
          loading.dismiss();
          this.toast.create({ message: 'Word saved successfully.', duration: 3000 }).present();
        })
        .catch((e) => {
          loading.dismiss();
          this.toast.create({ message: 'Error saving the word. Please try again.', duration: 3000 }).present();
        })
    } else {
      loading.dismiss();
    }
  }

}
