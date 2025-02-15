/**  DEVELOPED BY - TEAM F - PECUNIA
 *  DATE OF CREATION - 10/10/2019
 *  PECUNIA COMPONENT
 * 
*/



import { FormGroup, ValidationErrors } from '@angular/forms';

export class PecuniaComponentBase {
  getFormGroupErrors(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(key => {
      const controlErrors: ValidationErrors = formGroup.get(key).errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach(keyError => {
          console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
        });
      }
    });
  }
}


