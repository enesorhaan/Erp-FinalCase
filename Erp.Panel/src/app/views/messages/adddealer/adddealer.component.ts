import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MessagesService } from 'src/app/services/messages.service';

@Component({
  selector: 'app-adddealer',
  templateUrl: './adddealer.component.html',
  styleUrls: ['./adddealer.component.scss']
})
export class AdddealerComponent {
  messageForm = new FormGroup({
    transmitterMessage: new FormControl(''),
  })

  constructor(
    private messageService: MessagesService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  onSubmit(){
    this.messageService.addDealer(this.messageForm.value).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/message/list/dealer']);
      },
      error: error => {
        console.log(error, "Error");
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }
}
