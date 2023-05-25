import { Modal, ModalBody, Spinner } from "reactstrap";
import React, { useState } from "react";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";

const DeleteCategory = ({ isOpen, toggle, itemId, removeData }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const hadnleDeleteClick = () => {
    setIsLoading(true);

    fetchWrapper
      .delete("api/category/deletecategory/" + itemId)
      .then(() => {
        setIsLoading(false);
        removeData(itemId);
        toggle();
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  };

  return (
    <Modal isOpen={isOpen} toggle={toggle} centered={true}>
      {error ? <Error message={error} /> : null}
      <ModalBody className={"py-3 px-5"}>
        <div className={"mt-2 text-center"}>
          <lord-icon
            src={"https://cdn.lordicon.com/gsqxdxog.json"}
            trigger={"loop"}
            colors={"primary:#f7b84b,secondary:#f06548"}
            style={{ width: "100px", height: "100px" }}
          ></lord-icon>
          <div className={"mt-4 pt-2 fs-15 mx-4 mx-sm-5"}>
            <h4>А вы уверены ?</h4>
            <p className={"text-muted mx-4 mb-0"}>
              А вы уверены что хотите удалить эту запись ?
            </p>
          </div>
        </div>
        <div className={"d-flex gap-2 justify-content-center mt-4 mb-2"}>
          <button
            type={"button"}
            className={"btn w-sm btn-light"}
            data-bs-dismiss={"modal"}
            onClick={toggle}
          >
            Закрыть
          </button>
          <button
            type={"button"}
            className={"btn w-sm btn-danger"}
            id={"delete-record"}
            onClick={hadnleDeleteClick}
            disabled={isLoading}
          >
            {isLoading ? (
              <Spinner size={"sm"} className="me-2">
                Loading...
              </Spinner>
            ) : null}
            Удалить
          </button>
        </div>
      </ModalBody>
    </Modal>
  );
};

export default DeleteCategory;