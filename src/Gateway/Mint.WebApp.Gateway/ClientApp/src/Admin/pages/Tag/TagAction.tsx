import React, { FC, useState } from "react";
import {
  Col,
  Modal,
  ModalBody,
  ModalHeader,
  Row,
  FormFeedback,
  Button,
  Spinner,
} from "reactstrap";
import { useForm } from "react-hook-form";
import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { ITag } from "../../../services/admin/ITag";
import { newTag, updateTag } from "../../../services/admin/tags/tag";
import { fetch } from "../../../helpers/fetch";
import { useDispatch } from "react-redux";
import { useGuid } from "../../../hooks/useGuid";

interface ITagAction {
  tag: ITag;
  isEdit: boolean;
  isOpen: boolean;
  toggle: () => void;
}

const TagAction: FC<ITagAction> = ({ tag, isEdit, isOpen, toggle }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const dispatch = useDispatch();
  const guid = useGuid();

  const onSubmit = (values: ITag) => {
    setIsLoading(true);

    if (isEdit) {
      values.value = tag.value;

      dispatch(updateTag(fetch(), values))
        .then(() => {
          setIsLoading(false);
          reset();
          toggle();
        })
        .catch(() => {
          setIsLoading(false);
        });
    } else {
      values.value = guid;

      dispatch(newTag(fetch(), values))
        .then(() => {
          setIsLoading(false);
          console.log("togglllllllllllllllllllllllllllllllle");
          reset();
          toggle();
        })
        .catch(() => {
          setIsLoading(false);
          console.log("error");
        });
    }
  };

  const validation = Yup.object().shape({
    label: Yup.string()
      .required("Заполните обязательное поле")
      .min(2, "Минимальная длина строки 3 символа")
      .max(25, "Максимальная длина строки 25 символов"),
    translate: Yup.string()
      .required("Заполните обязательное поле")
      .min(2, "Минимальная длина строки 3 символа")
      .max(25, "Максимальная длина строки 25 символов"),
  });

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<ITag>({
    resolver: yupResolver(validation),
  });

  return (
    <React.Fragment>
      <Modal isOpen={isOpen} toggle={toggle} className={"border-0"}>
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={toggle}
          style={{ borderBottom: "1px" }}
        >
          {isEdit ? "Изменить" : "Добавить"}
        </ModalHeader>
        <ModalBody>
          <form onSubmit={handleSubmit(onSubmit)}>
            <Row>
              <Col lg={12} className={"form-group mb-3"}>
                <label htmlFor={"label"} className={"form-label"}>
                  Название
                </label>
                <input
                  type={"text"}
                  id={"name"}
                  className={`form-control ${errors.label ? "is-invalid" : ""}`}
                  placeholder={"Введите название"}
                  defaultValue={tag?.label || ""}
                  {...register("label")}
                />
                <FormFeedback type={"invalid"}>
                  {errors.label?.message}
                </FormFeedback>
              </Col>
              <Col lg={12} className={"form-group mb-3"}>
                <label htmlFor={"translate"} className={"form-label"}>
                  Перевод
                </label>
                <input
                  type={"text"}
                  id={"name"}
                  className={`form-control ${errors.label ? "is-invalid" : ""}`}
                  placeholder={"Введите перевод"}
                  defaultValue={tag?.translate || ""}
                  {...register("translate")}
                />
                <FormFeedback type={"invalid"}>
                  {errors.translate?.message}
                </FormFeedback>
              </Col>
              <div className={"d-flex justify-content-end align-items-center"}>
                <Button
                  type={"button"}
                  color={"danger"}
                  className={"me-3"}
                  onClick={toggle}
                >
                  <i className={"ri-close-line"}></i> Отмена
                </Button>
                <Button type={"submit"} color={"success"} disabled={isLoading}>
                  {isLoading ? (
                    <Spinner size={"sm"} className={"me-2"}>
                      Loading...
                    </Spinner>
                  ) : (
                    <i className={"ri-check-double-fill"}></i>
                  )}{" "}
                  Сохранить
                </Button>
              </div>
            </Row>
          </form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default TagAction;