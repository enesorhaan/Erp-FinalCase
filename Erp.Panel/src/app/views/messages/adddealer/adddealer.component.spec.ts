import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdddealerComponent } from './adddealer.component';

describe('AdddealerComponent', () => {
  let component: AdddealerComponent;
  let fixture: ComponentFixture<AdddealerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdddealerComponent]
    });
    fixture = TestBed.createComponent(AdddealerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
