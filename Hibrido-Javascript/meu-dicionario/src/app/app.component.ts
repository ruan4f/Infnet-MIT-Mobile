import { Component, ViewChild } from '@angular/core';
import { Platform, Nav } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';

import { HomePage } from '../pages/home/home';
import { LoginPage } from '../pages/login/login';
import { AddWordPage } from '../pages/add-word/add-word';
import { Storage } from '@ionic/storage';

export interface MenuItem {
  title: string;
  component: any;
  icon: string;
}

@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  @ViewChild(Nav) nav: Nav;

  rootPage: any = LoginPage;

  appMenuItems: Array<MenuItem>;

  constructor(
    public platform: Platform,
    public statusBar: StatusBar,
    public splashScreen: SplashScreen,
    private storage: Storage
  ) {
    this.initializeApp();

    this.appMenuItems = [
      { title: 'My Words', component: HomePage, icon: 'home' },
      { title: 'Add Word', component: AddWordPage, icon: 'add-circle' }      
    ];
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.splashScreen.hide();

      this.statusBar.styleDefault();
      this.statusBar.overlaysWebView(false);
    });
  }


  openPage(page) {    
    this.nav.setRoot(page.component);
  }

  logout() {
    this.storage.clear().then(() => {
      this.nav.setRoot(LoginPage);
    });    
  }
}

