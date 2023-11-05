import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { StorageService } from '../../../services/storage.service';

import { ClassToggleService, HeaderComponent } from '@coreui/angular';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-default-header',
  templateUrl: './default-header.component.html',
})
export class DefaultHeaderComponent extends HeaderComponent {

  @Input() sidebarId: string = "sidebar";

  public newMessages = new Array(4)
  public newTasks = new Array(5)
  public newNotifications = new Array(5)
  user:any;

  constructor(
    private classToggler: ClassToggleService,
    private storage: StorageService,
    private auth: AuthService
  ) {
    super();
  }

  ngOnInit(): void {
    this.user = this.storage.getUser();
  }

  signOut(){
    this.auth.logOut();
  }

}
