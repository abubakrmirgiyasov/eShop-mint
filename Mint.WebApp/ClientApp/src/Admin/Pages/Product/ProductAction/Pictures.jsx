import React, { useState } from "react";
import { Button, Col, Row, Spinner, TabPane } from "reactstrap";
import PreviewMultiImage from "../../../components/Dropzone/PreviewMultiImage";
import { Error } from "../../../../components/Notification/Error";
import { Success } from "../../../../components/Notification/Success";
import { fetchWrapper } from "../../../../helpers/fetchWrapper";

const Pictures = ({ isAdded, dataForUpdate }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [photos, setPhotos] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (photos) {
      setIsLoading(true);

      const formData = new FormData();
      formData.append("productId", dataForUpdate?.id);
      formData.append("fileType", "products");

      photos.forEach((file, i) => formData.append(`files[${i}]`, photos[i]));

      fetchWrapper
        .put("api/product/updateproductpictures", formData, false)
        .then((response) => {
          setIsLoading(false);
          setSuccess(response);
        })
        .catch((error) => {
          setError(error);
          setIsLoading(false);
        });
    } else {
      setError("Выберете картинку для вашего продукта.");
    }
  };

  function handleUpdateFiles(files) {
    setPhotos(files.map((file) => file.file));
  }

  return (
    <TabPane tabId={3}>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success} /> : null}
      {isAdded ? (
        isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <div className={"spinner-grow text-success"} role={"status"}>
              <span className={"visually-hidden"}>Loading...</span>
            </div>
          </div>
        ) : (
          <form onSubmit={handleSubmit}>
            <Row>
              <Col lg={12}>
                <PreviewMultiImage handleFiles={handleUpdateFiles} />
              </Col>
              <Col
                lg={12}
                className={"d-flex justify-content-end align-items-end"}
              >
                <Button
                  type={"submit"}
                  color={"primary"}
                  className={"btn btn-primary"}
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <Spinner size={"sm"} className={"me-2"}>
                      Loading...
                    </Spinner>
                  ) : null}
                  <i className={"ri-check-double-line"}></i> Сохранить
                </Button>
              </Col>
            </Row>
          </form>
        )
      ) : (
        <div className={"d-flex flex-column align-items-center"}>
          <h3 className={"text-center"}>
            Сначала вам нужно создать товар, чтобы заполнить остальные поля.
          </h3>
          <h5 className={"text-center text-muted fs-14 mt-3"}>
            Вернитесь на вкладку Информация чтобы создать.
          </h5>
        </div>
      )}
    </TabPane>
  );
};

export default Pictures;
