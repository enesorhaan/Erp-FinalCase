import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListorderbyidComponent } from './listorderbyid.component';

describe('ListorderbyidComponent', () => {
  let component: ListorderbyidComponent;
  let fixture: ComponentFixture<ListorderbyidComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListorderbyidComponent]
    });
    fixture = TestBed.createComponent(ListorderbyidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
