//
//  ViewController.swift
//  meusmangas
//
//  Created by Teste on 29/08/17.
//  Copyright © 2017 Ruan. All rights reserved.
//

import UIKit
import Firebase
import FirebaseAuth

class LoginController: UIViewController {

    @IBOutlet weak var emailTextField: UITextField!
    @IBOutlet weak var passwordTextField: UITextField!
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {	
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
  
    
    @IBAction func loginAction(_ sender: AnyObject) {
        
        if self.emailTextField.text == "" || self.passwordTextField.text == "" {
            
            //Exibe uma mensagem dizendo para preencher os campos
            let alertController = UIAlertController(title: "Error", message: "Por favor entre com o e-mail e senha", preferredStyle: .alert)
            
            let defaultAction = UIAlertAction(title: "OK", style: .cancel, handler: nil)
            alertController.addAction(defaultAction)
            
            self.present(alertController, animated: true, completion: nil)
            
        } else {            
            Auth.auth().signIn(withEmail: self.emailTextField.text!, password: self.passwordTextField.text!) { (user, error) in
                
                if error == nil {
                    //Redireciona para a tela de mangás caso o login esteja certo
                    let vc = self.storyboard?.instantiateViewController(withIdentifier: "Home")
                    self.present(vc!, animated: true, completion: nil)
                    
                } else {
                    
                    //Exibe uma mensagem caso aconteça algum erro
                    let alertController = UIAlertController(title: "Error", message: error?.localizedDescription, preferredStyle: .alert)
                    
                    let defaultAction = UIAlertAction(title: "OK", style: .cancel, handler: nil)
                    alertController.addAction(defaultAction)
                    
                    self.present(alertController, animated: true, completion: nil)
                }
            }
        }
    }
}

