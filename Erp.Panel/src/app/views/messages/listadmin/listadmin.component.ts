import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessagesService } from 'src/app/services/messages.service';

@Component({
  selector: 'app-listadmin',
  templateUrl: './listadmin.component.html',
  styleUrls: ['./listadmin.component.scss']
})
export class ListadminComponent implements OnInit, OnDestroy {
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
    this.messageService.getAdmin().subscribe(  (data:any) => {
      this.message = data.response;
      console.log(this.message);
    })
  }

  ngOnDestroy(): void {
    console.log("Destroy");
  }
}
