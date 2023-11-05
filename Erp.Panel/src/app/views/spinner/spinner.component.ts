import { Component } from '@angular/core';
import { LoaderService } from '../../services/loader.service';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss']
})
export class SpinnerComponent {

  public showSpinner$: Observable<any>

  constructor(loaderService: LoaderService) { 
    this.showSpinner$ = loaderService.pendingHttpRequest$
    .pipe(map(pendingHttpRequests => {
      return pendingHttpRequests > 0
    }))
  }
}
