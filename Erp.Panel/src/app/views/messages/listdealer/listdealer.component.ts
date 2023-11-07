import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessagesService } from 'src/app/services/messages.service';

@Component({
  selector: 'app-listdealer',
  templateUrl: './listdealer.component.html',
  styleUrls: ['./listdealer.component.scss']
})

export class ListdealerComponent implements OnInit, OnDestroy {
  message:any[] = []
  
  constructor(
    private messageService: MessagesService,
    private router: Router,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.messageService.getDealer().subscribe(  (data:any) => {
      this.message = data.response;
      console.log(this.message);
    })
  }
  
  ngOnDestroy(): void {
    console.log("Destroy");
  }
}
