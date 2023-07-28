import React, { useCallback, useEffect, useState } from "react";

const VALUE = "value";
const ERROR = "error";
const REQUIRED_FIELD_ERROR = "Заполните обязательное поле";

/**
 * Determines a value if it's an object
 *
 * @param {object} value
 */
function isObject(value: any): boolean {
  return typeof value === "object" && value !== null;
}

/**
 *
 * @param {string} value
 * @param {boolean} isRequired
 */
function isRequired(value: string, isRequired: boolean): string {
  if (!value && isRequired) {
    return REQUIRED_FIELD_ERROR;
  }
  return "";
}

function getPropValues(stateSchema: any, prop: string): Record<string, any> {
  return Object.keys(stateSchema).reduce(
    (accumulator: Record<string, any>, curr) => {
      accumulator[curr] = !prop ? false : stateSchema[curr][prop];
      return accumulator;
    },
    {}
  );
}

/**
 * Custom hooks to validate your Form...
 *
 * @param {object} stateSchema model you stateSchema.
 * @param {object} stateValidatorSchema model your validation.
 * @param {function} submitFormCallback function to be executed during form submission.
 */
export function useForm(
  stateSchema: Record<string, any> = {},
  stateValidatorSchema: Record<string, any> = {},
  submitFormCallback: (values: Record<string, any>) => void
) {
  const [state, setStateSchema] = useState(stateSchema);

  const [values, setValues] = useState<Record<string, any>>(
    getPropValues(state, VALUE)
  );
  const [errors, setErrors] = useState<Record<string, any>>(
    getPropValues(state, ERROR)
  );
  const [dirty, setDirty] = useState<Record<string, boolean>>(
    getPropValues(state, "dirty")
  );

  const [disable, setIsDisable] = useState<boolean>(true);
  const [isDirty, setIsDirty] = useState<boolean>(false);

  useEffect(() => {
    setStateSchema(stateSchema);
    setIsDisable(true);
    setInitialErrorState();
  }, []);

  useEffect(() => {
    if (isDirty) {
      setIsDisable(validateErrorState());
    }
  }, [errors, isDirty]);

  const validateFormFields = useCallback(
    (name: string, value: any) => {
      const validator = stateValidatorSchema;

      if (!validator[name]) return "";

      const field = validator[name];

      let error = "";
      error = isRequired(value, field.required);

      if (isObject(field["validator"]) && error === "") {
        const fieldValidator = field["validator"];

        const testFunc = fieldValidator["func"];
        if (testFunc(value, values)) {
          error = fieldValidator["error"];
        }
      }
      return error;
    },
    [stateValidatorSchema, values]
  );

  const setInitialErrorState = useCallback(() => {
    Object.keys(errors).map((name) =>
      setErrors((prevState) => ({
        ...prevState,
        [name]: validateFormFields(name, values[name]),
      }))
    );
  }, [errors, values, validateFormFields]);

  const validateErrorState = useCallback(
    () => Object.values(errors).some((error) => error),
    [errors]
  );

  const handleOnChange = useCallback(
    (event: React.ChangeEvent<HTMLInputElement>) => {
      setIsDirty(true);

      const name = event.target.name;
      const value = event.target.value;

      const error = validateFormFields(name, value);

      setValues((prevState) => ({ ...prevState, [name]: value }));
      setErrors((prevState) => ({ ...prevState, [name]: error }));
      setDirty((prevState) => ({ ...prevState, [name]: true }));
    },
    [validateFormFields]
  );

  const handleOnSubmit = useCallback(
    (event: React.FormEvent<HTMLFormElement>) => {
      event.preventDefault();

      if (!validateErrorState()) {
        submitFormCallback(values);
      }
    },
    [validateErrorState, submitFormCallback, values]
  );

  return {
    values,
    errors,
    disable,
    dirty,
    setValues,
    setErrors,
    handleOnChange,
    handleOnSubmit,
  };
}
