import React, { FC, useState } from "react";
import Dropzone from "react-dropzone";
import { Card, Col, Row } from "reactstrap";
import { Link } from "react-router-dom";

interface ISingleImage {
  currentImage: string;
  name: string | null;
  onChange: (e: FileWithPreview[]) => void;
}

interface FileWithPreview extends File {
  preview: string;
  formattedSize: string;
}

const SingleImage: FC<ISingleImage> = ({ currentImage, name, onChange }) => {
  const [selectedFiles, setSelectedFiles] = useState<FileWithPreview[]>([]);
  const [parentImage, setParentImage] = useState<string | null>(currentImage);

  const handleFileDrop = (files: FileList) => {
    const formattedFiles: FileWithPreview[] = Array.from(files).map((file) =>
      Object.assign(file, {
        preview: URL.createObjectURL(file),
        formattedSize: droppedImageSize(file.size),
      })
    ) as FileWithPreview[];

    setSelectedFiles(formattedFiles);
    onChange(formattedFiles);
    setParentImage(null);
  };

  const droppedImageSize = (bytes: number, decimals = 2): string => {
    if (bytes === 0) return "0 Bytes";

    const k = 1024;
    const dm = decimals > 0 ? decimals : 0;
    const sizes = ["Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"];
    const res = Math.floor(Math.log(bytes) / Math.log(k));
    return (
      parseFloat((bytes / Math.pow(k, res)).toFixed(dm)) + " " + sizes[res]
    );
  };

  const currentImageSize = (image: string): number => {
    // real formula to count image size by base64
    // https://stackoverflow.com/questions/29939635/how-to-get-file-size-of-newly-created-image-if-src-is-base64-string
    const base64 = "data:image/png;base64,";
    const imageLength = image.length - base64.length;
    const b = 0.5624896334383812;
    const sizeInBytes = 4 * Math.ceil(imageLength / 3) * b;
    return sizeInBytes / 1000;
  };

  return (
    <React.Fragment>
      <Dropzone
        onDrop={handleFileDrop}
        accept={{
          "image/jpeg": [],
          "image/png": [],
          "image/svg": [],
          "image/webp": [],
        }}
        multiple={false}
      >
        {({ getRootProps }) => (
          <div className={"dropzone dz-clickable"}>
            <div className={"dz-message needsclick"} {...getRootProps()}>
              <div className={"mb-3"}>
                <i
                  className={"display-4 text-muted ri-upload-cloud-2-fill"}
                ></i>
              </div>
              <h4>Перетащите файлы сюда или нажмите, чтобы загрузить.</h4>
            </div>
          </div>
        )}
      </Dropzone>
      <div className={"list-unstyled mb-0"} id={"file-previews"}>
        {selectedFiles.map((file, index) => (
          <Card
            className={
              "mt-1 mb-0 shadow-none border dz-processing dz-image-preview dz-success dz-complete"
            }
            key={index + "-file"}
          >
            <div className={"p-2"}>
              <Row className={"align-items-center"}>
                <Col className={"col-auto"}>
                  <img
                    data-dz-thumbnail={""}
                    height={80}
                    className={"avatar-sm rounded bg-light"}
                    alt={file.name}
                    src={file.preview}
                  />
                </Col>
                <Col>
                  <Link to={"#"} className={"text-muted font-weight-bold"}>
                    {file.name}
                  </Link>
                  <p className="mb-0">
                    <strong>{file.formattedSize}</strong>
                  </p>
                </Col>
              </Row>
            </div>
          </Card>
        ))}
        {parentImage && (
          <Card
            className={
              "mt-1 mb-0 shadow-none border dz-processing dz-image-preview dz-success dz-complete"
            }
          >
            <div className={"p-2"}>
              <Row className={"align-items-center"}>
                <Col className={"col-auto"}>
                  <img
                    data-dz-thumbnail={""}
                    height={"80"}
                    className={"avatar-sm rounded bg-light"}
                    alt=""
                    src={parentImage}
                  />
                </Col>
                <Col>
                  <Link to="#" className={"text-muted font-weight-bold"}>
                    {name}
                  </Link>
                  <p className="mb-0">
                    <strong>
                      {currentImageSize(parentImage).toFixed(2)} KB
                    </strong>
                  </p>
                </Col>
              </Row>
            </div>
          </Card>
        )}
      </div>
    </React.Fragment>
  );
};

export default SingleImage;
