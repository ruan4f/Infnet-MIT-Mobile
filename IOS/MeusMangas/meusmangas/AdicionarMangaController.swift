//
//  AdicionarMangaController.swift
//  meusmangas
//
//  Created by Ruan on 24/09/17.
//  Copyright © 2017 Ruan. All rights reserved.
//

import UIKit
import Firebase
import FirebaseDatabase
import FirebaseAuth
import MapKit

/**
 Esse controller é responsável por adicionar os mangás no firebase
 */
class AdicionarMangasController: UIViewController, UITableViewDelegate, UITableViewDataSource, CLLocationManagerDelegate {
    
    var refMangas: DatabaseReference!
    var locationManager = CLLocationManager()
    
    @IBOutlet weak var mangaTextField: UITextField!
    
    @IBOutlet weak var tableViewMangas: UITableView!
    
    var listaMangas = [MangaModel]()
    
    public func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int{
        return listaMangas.count
    }
    
    @IBAction func addMangaButton(_ sender: UIButton) {
        adicionaManga()
    }
    
    /**
     Método que cria a célula da tableView
     Ele pega o mangá com o mesmo index na lista de mangás do firebase
     */
    public func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell{
        let cell = tableView.dequeueReusableCell(withIdentifier: "cell", for: indexPath) as! TableViewMangaCell
        
        let manga: MangaModel
        
        manga = listaMangas[indexPath.row]
        
        cell.labelManga.text = manga.nome
        
        return cell
    }
    
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        
        let manga  = listaMangas[indexPath.row]
        
        let alertController = UIAlertController(title: manga.nome, message: "Entre com o novo nome ", preferredStyle: .alert)
        
        let saveAction = UIAlertAction(title: "Salvar", style: .default) { (_) in
            
            let id = manga.id
            
            let nome = alertController.textFields?[0].text
            
            self.atualizarManga(id: id!, nome: nome!)
        }
        
        let cancelAction = UIAlertAction(title: "Excluir", style: .cancel) { (_) in
            
            self.excluirManga(id: manga.id!)
        }
        
        alertController.addTextField { (textField) in
            textField.text = manga.nome
        }
        
        alertController.addAction(saveAction)
        alertController.addAction(cancelAction)
        
        present(alertController, animated: true, completion: nil)
    }
    
    /**
     Função que adiciona o mangá no database do firebase e atualiza a lista do tableView
     */
    func adicionaManga(){
        //Gera um identificador para o mangá
        //e coloca na variável
        let key = refMangas.childByAutoId().key
        
        //Cria o mangá, obtendo os valores do textField, coordenadas do usuário
        let manga = ["id":key,
                      "nome": mangaTextField.text! as String,
                      "latitude": UserDefaults.standard.value(forKey: "LAT") as! String,
                      "longitude": UserDefaults.standard.value(forKey: "LON") as! String
        ]
        
        //Adiciona o mangá dentro da chave que foi gerada anteriormente
        refMangas.child(key).setValue(manga)
        
        mangaTextField.text = ""
        
        showSuccessMessage(title: "Adicionado", message: "Mangá adicionado com sucesso")
    }
    
    func atualizarManga(id:String, nome:String){
        //cria o mangá com os novos valores
        let manga = ["id":id,
                      "nome": nome,
                      "latitude": UserDefaults.standard.value(forKey: "LAT") as? String,
                      "longitude": UserDefaults.standard.value(forKey: "LON") as? String
        ]
        
        refMangas.child(id).setValue(manga)
        
        showSuccessMessage(title: "Atualizado", message: "Mangá atualizado com sucesso")
    }
    
    
    func excluirManga(id:String){
        refMangas.child(id).setValue(nil)
        
        showSuccessMessage(title: "Excluído", message:  "Mangá deletado com sucesso")
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        refMangas = Database.database().reference().child("mangas");
        
        //Verifica se a lista de mangás tem alteração e atualiza a mesma, tanto no firebase, quanto na tableView do app
        refMangas.observe(DataEventType.value, with: { (snapshot) in
            
            if snapshot.childrenCount > 0 {
                
                self.listaMangas.removeAll()
                
                for artists in snapshot.children.allObjects as! [DataSnapshot] {
                    
                    let mangaObject = artists.value as? [String: AnyObject]
                    
                    let nomeManga  = mangaObject?["nome"]
                    let idManga  = mangaObject?["id"]
                    let latitudadeManga = mangaObject?["latitude"]
                    let longitudeManga = mangaObject?["longitude"]
                    
                    let manga = MangaModel(id: idManga as! String?, nome: nomeManga as! String?, latitude: latitudadeManga as! String?, longitude: longitudeManga as! String?)
                    
                    self.listaMangas.append(manga)
                }
                
                self.tableViewMangas.reloadData()
            }
        })
        
        locationManager.requestAlwaysAuthorization()
        locationManager.requestWhenInUseAuthorization()
        
        if CLLocationManager.locationServicesEnabled() {
            locationManager.delegate = self
            locationManager.desiredAccuracy = kCLLocationAccuracyBest
            locationManager.startUpdatingLocation()
        }
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func locationManager(_ manager: CLLocationManager, didUpdateLocations locations: [CLLocation]) {
        if let location = locations.first {
            print(location.coordinate)
            
            UserDefaults.standard.set(String(format: "%.4f", location.coordinate.latitude), forKey: "LAT")
            UserDefaults.standard.set(String(format: "%.4f", location.coordinate.longitude), forKey: "LON")
            UserDefaults().synchronize()
        }
    }
    
    func locationManager(_ manager: CLLocationManager, didFailWithError error: Error)
    {
        print("Error \(error)")
    }
    
    func locationManager(_ manager: CLLocationManager, didChangeAuthorization status: CLAuthorizationStatus) {
        if(status == CLAuthorizationStatus.denied) {
            showLocationDisabledPopUp()
        }
    }
    
    //Exine uma mensagem caso o usuário não tenho permitido o acesso ao GPS
    func showLocationDisabledPopUp() {
        let alertController = UIAlertController(title: "Sem acesso a sua localização",
                                                message: "O aplicativo precisa saber da sua localização",
                                                preferredStyle: .alert)
        
        let cancelAction = UIAlertAction(title: "Cancelar", style: .cancel, handler: nil)
        alertController.addAction(cancelAction)
        
        let openAction = UIAlertAction(title: "Abrir Configurações", style: .default) { (action) in
            if let url = URL(string: UIApplicationOpenSettingsURLString) {
                UIApplication.shared.open(url, options: [:], completionHandler: nil)
            }
        }
        alertController.addAction(openAction)
        
        self.present(alertController, animated: true, completion: nil)
    }
    
    /**
     Função de logout da aplicação
     
     Ela desloga o usuário e redireciona para a tela de login
     */
    @IBAction func logOutAction(sender: AnyObject) {
        if Auth.auth().currentUser != nil {
            do {
                try Auth.auth().signOut()
                let vc = UIStoryboard(name: "Main", bundle: nil).instantiateViewController(withIdentifier: "Login")
                present(vc, animated: true, completion: nil)
                
            } catch let error as NSError {
                print(error.localizedDescription)
            }
        }
    }
    
    func showSuccessMessage(title : String, message: String){
        let alert = UIAlertController(title: title, message: message, preferredStyle: UIAlertControllerStyle.alert)
        
        alert.addAction(UIAlertAction(title: "Ok", style: UIAlertActionStyle.cancel, handler: nil ))
        
        //exibir alerta tela na tela atual
        self.present(alert, animated: true, completion: nil)
    }
    
    
    
}
