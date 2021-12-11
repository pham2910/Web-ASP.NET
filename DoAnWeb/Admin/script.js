function confirmLogOut(e) {
  {
      if(confirm('Do you want log out of Website')) {
          e.preventDefault();
          confirmLogOut.submit();
        } else {
            close(alert);
            return;
        }
  }
}
