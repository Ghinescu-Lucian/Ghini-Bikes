import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import Button from "@material-ui/core/Button";
import ShareIcon from "@material-ui/icons/Share";
import { Avatar, IconButton, CardMedia } from "@material-ui/core";
import "./CSS/ProductCard.css";
import { CloseButton } from "./CloseButton";

const ProductCard = props => {
  const { manufacturer, model, description, image, price } = props;
  var popupViews = document.querySelectorAll('.popup-view');
  var popupBtns = document.querySelectorAll('.popup-btn');
  var closeBtns = document.querySelectorAll('.close-btn');

  //javascript for quick view button
  var popup = function (popupClick) {
    popupViews[popupClick].classList.add('active');
  }

  popupBtns.forEach((popupBtn, i) => {
    popupBtn.addEventListener("click", () => {
      popup(i);
    });
  });
  //javascript for close button
  closeBtns.forEach((closeBtn) => {
    closeBtn.addEventListener("click", () => {
      popupViews.forEach((popupView) => {
        popupView.classList.remove('active');
      });
    });
  });

  return (
    <div>
      <Card>
        <CardHeader
          avatar={<Avatar src={image} />} 
          action={
            <IconButton aria-label="settings">
              <ShareIcon />
            </IconButton>
          }
          title={manufacturer}
          subheader={model}
        />
        <CardMedia style={{ height: "200px", width:"350px" }} image={image} />
        <CardContent>
          <Typography variant="body2" component="p">
            {description}
          </Typography>
        </CardContent>
        <CardActions>
          {/* <Button size="small">BUY NOW</Button> */}
          {/* <Button size="small">OFFER</Button> */}
          <Button className="popup-btn">Detalii</Button>
        </CardActions>
      </Card>
      <div className="product">
        <div className="popup-view">
          <div className="popup-card">
            <CloseButton/>
            <div className="product-img">
              <img style={{ height: "500px", width:"500px"}} src={image} />
            </div>
            <div className="info" style={{ height: "500px", width:"500px"}} >
              <h2>{manufacturer}<br /><span>{model}</span></h2>
              <p>{description}</p>
              <span className="price">{price} lei</span>
              <form method="POST" action="">
                <input type="hidden" name="hidden_name" value="" />
                <input type="hidden" name="hidden_price" value="" />
                <input type="hidden" name="hidden_idProduct" value="" />
                <input type="hidden" name="hidden_img" value="'.$res.'" />
                <input type="submit" name="add_to_cart" className="add-cart-btn" value="Adauga in cos" />
              </form>
            </div>
          </div>

        </div>
      </div>
    </div >

  );
};

export default ProductCard;