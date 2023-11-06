import { TestBed } from '@angular/core/testing';

import { CurrentaccountsService } from './currentaccounts.service';

describe('CurrentaccountsService', () => {
  let service: CurrentaccountsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrentaccountsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
