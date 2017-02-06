/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ContactListService } from './contact-list.service';

describe('ContactListService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContactListService]
    });
  });

  it('should ...', inject([ContactListService], (service: ContactListService) => {
    expect(service).toBeTruthy();
  }));
});
