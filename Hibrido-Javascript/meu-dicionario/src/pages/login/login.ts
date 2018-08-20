import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, MenuController, LoadingController, AlertController } from 'ionic-angular';
import { HomePage } from '../home/home';
import { AngularFireAuth } from 'angularfire2/auth';
import { Storage } from '@ionic/storage';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {

  form: FormGroup;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public menu: MenuController,
    private afAuth: AngularFireAuth,
    private storage: Storage,
    private formBuilder: FormBuilder,
    public loadingCtrl: LoadingController,
    public alertCtrl: AlertController
  ) {
    this.menu.swipeEnable(false);
    this.createForm();
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad LoginPage');
  }

  createForm() {
    this.form = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      password: ['', Validators.required]
    });
  }

  signIn() {
    let loading = this.loadingCtrl.create({
      content: 'Loading...'
    });
    loading.present();
    const { email, password } = this.form.value;

    this.afAuth.auth.signInWithEmailAndPassword(email, password).then(result => {
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

  signUp() {
    this.navCtrl.push('RegisterPage');
  }
}
