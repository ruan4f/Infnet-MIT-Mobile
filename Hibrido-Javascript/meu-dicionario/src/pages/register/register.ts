import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController, LoadingController } from 'ionic-angular';
import { Storage } from '@ionic/storage';
import { AngularFireAuth } from 'angularfire2/auth';
import { HomePage } from '../home/home';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@IonicPage()
@Component({
  selector: 'page-register',
  templateUrl: 'register.html',
})
export class RegisterPage {

  form: FormGroup;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    private afAuth: AngularFireAuth,
    private storage: Storage,
    private formBuilder: FormBuilder,
    public loadingCtrl: LoadingController,
    public alertCtrl: AlertController
  ) {
    this.createForm();
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad RegisterPage');
  }

  createForm() {
    this.form = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      password: ['', Validators.required]
    });
  }

  createUser() {
    let loading = this.loadingCtrl.create({
      content: 'Loading...'
    });
    loading.present();
    const { email, password } = this.form.value;

    this.afAuth.auth.createUserWithEmailAndPassword(email, password).then(result => {
      console.log(result);

      this.storage.set('uid', result.uid).then(() => {
        loading.dismiss();
        this.navCtrl.setRoot(HomePage);
      });
    }).catch(error => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: '',
        subTitle: error.message,
        buttons: ['Ok']
      });
      alert.present();
    });

  }

}
