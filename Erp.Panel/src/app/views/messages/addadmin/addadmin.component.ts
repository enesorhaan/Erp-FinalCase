import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DealerService } from 'src/app/services/dealer.service';
import { MessagesService } from 'src/app/services/messages.service';

@Component({
  selector: 'app-addadmin',
  templateUrl: './addadmin.component.html',
  styleUrls: ['./addadmin.component.scss']
})
export class AddadminComponent implements OnInit, OnDestroy {
  messageForm = new FormGroup({
    receiverId: new FormControl(''),
    transmitterMessage: new FormControl(''),
  })

  dealer:any[] = []

  constructor(
    private messageService: MessagesService,
    private dealerService: DealerService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  onSubmit(){
    this.messageService.addAdmin(this.messageForm.value).subscribe({
      next: data => {
        this.toastr.success('Message sent!', 'Success');
        this.router.navigate(['/message/list/admin']);
      },
      error: error => {
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }

  ngOnInit(): void {
    this.getDealer();
  }

  getDealer(){
    this.dealerService.get().subscribe(  (data:any) => {
      this.dealer = data.response;
    })
  }
  
  ngOnDestroy(): void {
  }
}
